import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Balanco } from '../models/balanco.model';

@Injectable({
    providedIn: 'root'
})

export class BalancoService {
    private url = `${environment.api}/Balanco`;

    constructor(private _httpClient: HttpClient) { }

    getBalancoMes(mes: number): Observable<Balanco[]> {
        return this._httpClient.get<Balanco[]>(`${this.url}/${mes}`);
    }

    conciliar(data: String) {
        return this._httpClient.post(`${this.url}/a/${data}`, null);
    }
}