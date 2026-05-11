import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TituloService {

  private apiUrl = 'http://localhost:8080/api/Titulos';

  constructor(private http: HttpClient) {}

  listar() {
    return this.http.get<any[]>(this.apiUrl);
  }

  criar(titulo: any) {
    return this.http.post(this.apiUrl, titulo);
  }

}