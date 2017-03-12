import {services} from './inversify.config';
import {Client} from './client/Client';
import {Drawer} from './ui/Drawer';

export class Program
{
    public static async main()
    {
        const client = services.get<Client>(Client);
        const drawer = services.get<Drawer>(Drawer);

        client.username = 'alena1488';
        client.password = 'P123';

        console.log(12321);

        const issues = await client.getIssues();
        drawer.drawIssues(issues);
    }
}