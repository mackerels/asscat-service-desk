import { Container } from "inversify";
import {Authenticator} from './authenticator/Authenticator';
import {Client} from './client/Client';
import {Drawer} from './ui/Drawer';

const services = new Container();

services.bind<Authenticator>(Authenticator).toSelf();
services.bind<Client>(Client).toSelf();
services.bind<Drawer>(Drawer).toSelf();

export { services };