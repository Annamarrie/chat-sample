import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import {
  HubConnection,
  HubConnectionBuilder,
  LogLevel,
} from '@microsoft/signalr';
import { from } from 'rxjs';
import { tap } from 'rxjs/operators';
import { chatMessage } from './chatMessage';
import { MessagePackHubProtocol } from '@microsoft/signalr-protocol-msgpack';
@Injectable({
  providedIn: 'root',
})
export class SignalrService {
  private hubConnection: HubConnection;
  public messages: chatMessage[] = [];
  public connectionId: string;
  private connectionUrl = 'https://localhost:44398/chatHub';

  constructor(private http: HttpClient) {}

  public connect = () => {
    this.startConnection();
    this.addListeners();
  };

  public sendMessageToHub(message: string) {
    var promise = this.hubConnection
      .invoke('BroadcastAsync', this.buildChatMessage(message))
      .then(() => {
        console.log('message sent successfully to hub');
      })
      .catch((err) =>
        console.log('error while sending a message to hub: ' + err)
      );

    return from(promise);
  }

  private getConnection(): HubConnection {
    return (
      new HubConnectionBuilder()
        .withUrl(this.connectionUrl)
        .withHubProtocol(new MessagePackHubProtocol())
        //  .configureLogging(LogLevel.Trace)
        .build()
    );
  }

  private buildChatMessage(message: string): chatMessage {
    return {
      ConnectionId: this.hubConnection.connectionId,
      Text: message,
      DateTime: new Date(),
    };
  }

  private startConnection() {
    this.hubConnection = this.getConnection();

    this.hubConnection
      .start()
      .then(() => {
        console.log('connection started');
        this.connectionId = this.hubConnection.connectionId;
      })
      .catch((err) =>
        console.log('error while establishing signalr connection: ' + err)
      );
  }

  private addListeners() {
    this.hubConnection.on('messageReceivedFromApi', (data: chatMessage) => {
      console.log('message received from API Controller');
      this.messages.push(data);
      this.scrollToBottom();
    });
    this.hubConnection.on('messageReceivedFromHub', (data: chatMessage) => {
      console.log('message received from Hub');
      this.messages.push(data);
      this.scrollToBottom();
    });
    this.hubConnection.on('newUserConnected', (_) => {
      console.log('new user connected');
    });
  }

  scrollToBottom() {
    setTimeout(() => {
      const elem = document.getElementsByClassName('messages-block')[0];
      if (elem) {
        elem.scroll(0, elem.scrollHeight);
      }
    }, 0);
  }
}
