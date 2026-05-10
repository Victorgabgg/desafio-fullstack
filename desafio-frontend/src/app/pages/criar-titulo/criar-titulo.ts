import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, FormGroup, FormArray, Validators } from '@angular/forms';
import { TituloService } from '../../services/titulo';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-criar-titulo',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule
  ],
  templateUrl: './criar-titulo.html',
  styleUrl: './criar-titulo.scss'
})
export class CriarTitulo {

  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private service: TituloService
  ) {
    this.form = this.fb.group({
      numeroTitulo: ['', Validators.required],
      nomeDevedor: ['', Validators.required],
      cpfDevedor: ['', Validators.required],
      percentualJuros: [0, Validators.required],
      percentualMulta: [0, Validators.required],
      parcelas: this.fb.array([])
    });
  }

  get parcelas(): FormArray {
    return this.form.get('parcelas') as FormArray;
  }

  addParcela() {
    const parcela = this.fb.group({
      numeroParcela: [this.parcelas.length + 1, Validators.required],
      dataVencimento: ['', Validators.required],
      valor: [0, Validators.required]
    });

    this.parcelas.push(parcela);
  }

  removeParcela(index: number) {
    this.parcelas.removeAt(index);
  }

  salvar() {
    if (this.form.invalid) {
      this.form.markAllAsTouched();
      return;
    }

    this.service.criar(this.form.value).subscribe({
      next: () => {
        alert('Título criado com sucesso!');
        this.form.reset();
        this.parcelas.clear();
      },
      error: (err) => {
        console.error('Erro ao criar título:', err);
        alert('Erro ao cadastrar título');
      }
    });
  }
}