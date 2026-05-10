import { Routes } from '@angular/router';

import { ListarTitulos } from './pages/listar-titulos/listar-titulos';
import { CriarTitulo } from './pages/criar-titulo/criar-titulo';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'titulos',
    pathMatch: 'full'
  },

  {
    path: 'titulos',
    component: ListarTitulos
  },

  {
    path: 'novo-titulo',
    component: CriarTitulo
  }
];