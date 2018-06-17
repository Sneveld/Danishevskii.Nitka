import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { UserDto } from '../DTO/user.dto';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()

export class UsersSevice {

    private url = "/api/user/";  

    constructor(private http: HttpClient) {
    }

    getUsers(pageCount: number, pageNumber: number): Observable<UserDto[]> {
        return this.http.get(this.url, { params: { pageCount: pageCount.toString(), pageNumber: pageNumber.toString()} }).pipe(map((data: any) => {
            let usersList = data.Data;
            return usersList.map(function (user: any) {
                let userDto = new UserDto();
                userDto.id = user.Id;
                userDto.firstName = user.FirstName;
                userDto.lastName = user.LastName;
                userDto.number = user.Number;
                userDto.salary = user.Salary;
                userDto.salaryRatio = user.SalaryRatio;
                return userDto;
            });
        }));
    }

    getUser(id: string): Observable<UserDto>  {
        return this.http.get(this.url, { params: { id: id } }).pipe(map((data: any) => {
            let user = data;
            let userDto = new UserDto();
            userDto.id = user.Id;
            userDto.firstName = user.FirstName;
            userDto.lastName = user.LastName;
            userDto.number = user.Number;
            userDto.salary = user.Salary;
            userDto.salaryRatio = user.SalaryRatio;
            return userDto;
        }));
    }

    addUser(user: UserDto) {
        var body = JSON.stringify(user); 
        return this.http.post(this.url, body, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }

    updateUser(user: UserDto) {
        var body = JSON.stringify(user);        
        return this.http.put(this.url, body, {
            headers: {
                'Content-Type': 'application/json'
            }
        });
    }

    deleteUser(user: UserDto) {
        return this.http.delete(this.url, { params: { id: user.id } });
    }
}