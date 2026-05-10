import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListarTitulos } from './listar-titulos';

describe('ListarTitulos', () => {
  let component: ListarTitulos;
  let fixture: ComponentFixture<ListarTitulos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListarTitulos],
    }).compileComponents();

    fixture = TestBed.createComponent(ListarTitulos);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
