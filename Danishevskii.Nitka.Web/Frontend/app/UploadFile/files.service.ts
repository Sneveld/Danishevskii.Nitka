import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

@Injectable()
export class FilesService {

    constructor(private http: HttpClient) { }

    upload(file: File): Observable<Object> {
        const formData: FormData = new FormData();
        formData.append('file', file, file.name);

        return this.http.post(`api/uploadFile`, formData);
    }
}