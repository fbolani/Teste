import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {
  title = 'Teste de Competência DDA';
  idNavbarActive: number;

  constructor(private router: Router) { }

  ngOnInit() {
    this.idNavbarActive = 1;
  }

  onNavClick(navClick: number) {
    this.idNavbarActive = navClick;
    if (navClick == 1)
      this.router.navigate(['/lancamentos']);
    else if (navClick == 2)
      this.router.navigate(['/conciliar']);
    else if (navClick == 3)
      this.router.navigate(['/relatorio-mensal']);
  }
}