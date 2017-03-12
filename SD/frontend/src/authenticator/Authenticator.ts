import {memoize} from '../decorators/memoize';
import {ProjectUrls} from '../urls/ProjectUrls';
import {injectable} from 'inversify';

@injectable()
export class Authenticator
{
    @memoize
    private static get API_CLIENT_CONFIG(): Map<string, string>
    {
        const map = new Map<string, string>();

        map.set('grant_type', 'password');
        map.set('client_id', 'crm-client');
        map.set('client_secret', 'crm-client-secret');

        return map;
    }

    private _token: string;

    get token(): string
    {
        return this._token;
    }

    public async authenticate(username: string, password: string)
    {
        const config = Authenticator.API_CLIENT_CONFIG;

        config.set('username', username);
        config.set('password', password);

        const form = new FormData();

        config.forEach((value, key) => form.append(key, value));

        const response = await fetch(ProjectUrls.TOKEN_AUTH, {
            method: 'POST',
            body: form
        });

        if (!response.ok) {
            throw new Error('Failed while receiving token.');
        }

        const json = await response.json();

        console.info('successfully received access token');
        this._token = json.access_token;

        return this._token;
    }
}