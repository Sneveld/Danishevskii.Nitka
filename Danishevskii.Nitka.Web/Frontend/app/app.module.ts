import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'; 
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { UploadFileComponent } from './UploadFile/upload-file.component';
import { UsersComponent } from './UsersCRUID/users.component';
import { UsersListComponent } from './UsersCRUID/UsersList/user-list.component';
import { UsersInfoComponent } from './UsersCRUID/UserInfo/user-info.component';

@NgModule({
    imports: [BrowserModule, HttpClientModule, FormsModule],
    declarations: [AppComponent, UploadFileComponent, UsersComponent, UsersListComponent, UsersInfoComponent],
    bootstrap: [AppComponent]
})
export class AppModule { }