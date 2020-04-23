import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class CompartilhadoService {
    constructor(private http: HttpClient) { }
    public ocultarMenu = false;
}
