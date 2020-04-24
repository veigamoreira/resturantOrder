import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { usuarioAdicionarRequestModel, usuarioAdicionarResponseModel } from '../../models/usuario.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  public headers: Headers = new Headers();

  constructor(private http: HttpClient) { }

  adicionar(request: usuarioAdicionarRequestModel): Observable<usuarioAdicionarResponseModel> {
    return this.http.post<usuarioAdicionarResponseModel>(`${environment.apiUrl}/order`, request);
  }

 
}
