import {injectable} from 'inversify';
import * as $ from 'jquery';

@injectable()
export class Drawer
{
    public drawIssues(json: any)
    {
        const issues = $('#issues');

        json.forEach(iss =>
        {
            issues.append('<div>' +
                'id: ' + iss.id + '<br>' +
                'topic: ' + iss.topic + '<br>' +
                'matter: ' + iss.matter + '<br>' +
                '</div><br>'
            );
        });
    }
}