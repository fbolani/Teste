import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lancamento } from '../models/lancamento.model';

@Injectable({
  providedIn: 'root'
})

export class LancamentoService {
  private url = `${environment.api}/Lancamento`;
  httpOptions = {
    headers: new HttpHeaders({
      'Accept': 'application/json',
      'Content-Type':  'application/json'
    })
  };
  constructor(private _httpClient: HttpClient) { }

  get(): Observable<Lancamento[]> {
    return this._httpClient.get<Lancamento[]>(`${this.url}`);
  }

  getById(id: number): Observable<Lancamento> {
    return this._httpClient.get<Lancamento>(`${this.url}/${id}`);
  }

  getByDate(data: any): Observable<Lancamento[]> {
    return this._httpClient.get<Lancamento[]>(`${this.url}/dia/${data}`);
  }

  post(model: Lancamento) {
    return this._httpClient.post(`${this.url}`, JSON.stringify(model), this.httpOptions);
  }

  put(id: number, model: Lancamento) {
    return this._httpClient.put(`${this.url}/${id}`, JSON.stringify(model), this.httpOptions);
  }

  delete(id: number) {
    return this._httpClient.delete(`${this.url}/${id}`);
  }
}