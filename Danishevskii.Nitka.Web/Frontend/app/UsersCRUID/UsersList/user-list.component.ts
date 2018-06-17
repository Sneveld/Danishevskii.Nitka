import { Input, Output, Component, OnInit, EventEmitter } from '@angular/core';
import { UserDto } from '../../DTO/user.dto';
import { UsersSevice } from '../users.service';

@Component({
    selector: 'user-list',
    templateUrl: './user-list.html',
    providers: []
})

export class UsersListComponent {
    @Input() users: UserDto[];
    @Output() selectUserEvent = new EventEmitter<UserDto>();
    @Output() userWasDeletedEvent = new EventEmitter<UserDto>();

    constructor(private usersService: UsersSevice) {
    }

    selectUser(user: UserDto) {
        this.selectUserEvent.emit(user);
    }

    deleteUser(user: UserDto) {
        this.usersService.deleteUser(user).subscribe(() => {
            this.userWasDeletedEvent.emit(user);
        });
    }
}