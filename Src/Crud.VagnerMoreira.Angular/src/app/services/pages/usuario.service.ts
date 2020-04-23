import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { usuarioAdicionarRequestModel, usuarioAdicionarResponseModel, usuarioListarResponseModel, usuarioDeletarResponseModel, usuarioObterResponseModel, usuarioEditarRequestModel, usuarioEditarResponseModel } from '../../models/usuario.model';
import { MarcaListarResponseModel } from 'src/app/models/marca.model';
import { ModeloListarResponseModel } from 'src/app/models/modelo.model';
import { VersaoListarResponseModel } from 'src/app/models/versao.model';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  public headers: Headers = new Headers();

  constructor(private http: HttpClient) { }

  adicionar(request: usuarioAdicionarRequestModel): Observable<usuarioAdicionarResponseModel> {
    return this.http.post<usuarioAdicionarResponseModel>(`${environment.apiUrl}/usuario/adicionar`, request);
  }

  editar(request: usuarioEditarRequestModel): Observable<usuarioEditarResponseModel> {
    return this.http.put<usuarioEditarResponseModel>(`${environment.apiUrl}/usuario/editar`, request);
  }

  deletar(request: number): Observable<usuarioDeletarResponseModel> {
    return this.http.delete<usuarioDeletarResponseModel>(`${environment.apiUrl}/usuario/deletar/${request}`);
  }

  obter(id: number): Observable<usuarioObterResponseModel> {
    return this.http.get<usuarioObterResponseModel>(`${environment.apiUrl}/usuario/obter/${id}`);
  }

  listar(): Observable<usuarioListarResponseModel[]> {
    return this.http.get<usuarioListarResponseModel[]>(`${environment.apiUrl}/usuario/listar`);
  }

 
}
