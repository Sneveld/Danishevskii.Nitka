import { Component, ViewChild } from '@angular/core';
import { UploadFileComponent } from './UploadFile/upload-file.component';
import { UsersComponent } from './UsersCRUID/users.component';

@Component({
    selector: 'app',
    templateUrl: './app.html',
    providers: [UploadFileComponent, UsersComponent]
})
export class AppComponent {
    @ViewChild('users') users: UsersComponent;

    dataLoaded() {
        this.users.reloadUsers();
    }
}
