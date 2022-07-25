import { Message } from "./message-model";


export class User {
    public id: string = '';
    public name: string = '';
    public connId: string = '';
    public messages: Array<Message> = [];
  }