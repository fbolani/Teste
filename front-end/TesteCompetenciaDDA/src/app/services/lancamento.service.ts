import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Lancamento } from '../models/lancamento.model';

@Injectable({
  providedIn: 'root'
})

export class LancamentoService {
  private url = `${environment.api}/Lancamento`;

  constructor(private _httpClient: HttpClient) { }

  get(): Observable<Lancamento[]> {
    return this._httpClient.get<Lancamento[]>(`${this.url}`);
  }

  getByDate(data: any): Observable<Lancamento[]> {
    return this._httpClient.get<Lancamento[]>(`${this.url}/dia/${data}`);
  }

  post(model: Lancamento) {
    return this._httpClient.post(`${this.url}`, JSON.stringify(model));
  }

  put(id: number, model: Lancamento) {
    return this._httpClient.put(`${this.url}/${id}`, JSON.stringify(model));
  }

  delete(id: number) {
    return this._httpClient.delete(`${this.url}/${id}`);
  }
}