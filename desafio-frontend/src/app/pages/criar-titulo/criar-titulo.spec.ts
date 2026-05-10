import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CriarTitulo } from './criar-titulo';

describe('CriarTitulo', () => {
  let component: CriarTitulo;
  let fixture: ComponentFixture<CriarTitulo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CriarTitulo],
    }).compileComponents();

    fixture = TestBed.createComponent(CriarTitulo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
