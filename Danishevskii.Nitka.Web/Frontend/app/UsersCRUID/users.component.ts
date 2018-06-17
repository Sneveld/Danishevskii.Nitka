import { Component, OnInit } from '@angular/core';
import { UsersSevice } from './users.service';
import { UserDto } from '../DTO/user.dto';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
    selector: 'users',
    templateUrl: './users.html',
    providers: [UsersSevice]
})

export class UsersComponent implements OnInit {

    constructor(private usersService: UsersSevice) {

    }
    currentUser: UserDto = new UserDto();
    currentPage: number = 1;
    pagesCount: number = 10;
    users: UserDto[];
    user: UserDto;

    public reloadUsers() {
        this.usersService.getUsers(this.pagesCount, this.currentPage).subscribe(data => this.users = data);
    }

    ngOnInit(): void {
        this.usersService.getUsers(this.pagesCount, this.currentPage).subscribe(data => this.users = data);
    }

    previosPage() {
        if (this.currentPage - 1 > 0) {
            this.currentPage = this.currentPage - 1;
            this.usersService.getUsers(this.pagesCount, this.currentPage).subscribe(data => this.users = data);
        }
    }

    nextPage() {
        this.currentPage = this.currentPage + 1;
        this.usersService.getUsers(this.pagesCount, this.currentPage).subscribe(data => this.users = data);
    }

    selectUser(user: UserDto) {
        this.currentUser = user;
    }

    deleteUser(user: UserDto) {
        this.usersService.getUsers(this.pagesCount, this.currentPage).subscribe(data => this.users = data);
        this.currentUser = new UserDto();
    }
}