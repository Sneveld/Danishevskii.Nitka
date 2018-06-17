import { Input, Output, Component, OnInit } from '@angular/core';
import { UserDto } from '../../DTO/user.dto';
import { UsersSevice } from '../users.service';

@Component({
    selector: 'user-info',
    templateUrl: './user-info.html',
    providers: [UsersSevice]
})

export class UsersInfoComponent {
    @Input() user: UserDto;

    constructor(private usersService: UsersSevice) {
    }

    save() {
        this.usersService.updateUser(this.user).subscribe(() => { });
    }
}