import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TituloService } from '../../services/titulo';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-listar-titulos',
  standalone: true,
  imports: [CommonModule, RouterModule, MatTableModule, MatCardModule, MatProgressSpinnerModule],
  templateUrl: './listar-titulos.html',
  styleUrl: './listar-titulos.scss'
})
export class ListarTitulos implements OnInit {

  titulos: any[] = [];
  loading = false;
  loaded = false;

  displayedColumns: string[] = [
  'numero',
  'devedor',
  'parcelas',
  'valorOriginal',
  'dias',
  'valorAtualizado'
];

  constructor(
    private service: TituloService,
    private cdr: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    console.log('NGONINIT EXECUTOU');
    this.carregarTitulos();
  }

  carregarTitulos() {
    this.loading = true;
    this.loaded = false;

    this.service.listar().subscribe({
      next: (data) => {
        console.log('DADOS RECEBIDOS:', data);

        this.titulos = data;
        this.loading = false;
        this.loaded = true;

        this.cdr.detectChanges(); 
      },
      error: (err) => {
        console.error(err);
        this.loading = false;
        this.loaded = true;

        this.cdr.detectChanges();
      }
    });
  }
}