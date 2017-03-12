import {injectable} from 'inversify';
import {Authenticator} from '../authenticator/Authenticator';
import {ProjectUrls} from '../urls/ProjectUrls';

@injectable()
export class Client
{
    private _authenticator: Authenticator;

    public username: string;
    public password: string;

    constructor(authenticator: Authenticator)
    {
        this._authenticator = authenticator;
    }

    public async getIssues()
    {
        const token = await this._authenticator.authenticate(this.username, this.password);

        const headers = new Headers();
        headers.append('Authorization', `Bearer ${token}`);

        const response = await fetch(ProjectUrls.ISSUE, {
            method: 'GET',
            headers: headers
        });

        return await response.json();
    }
}