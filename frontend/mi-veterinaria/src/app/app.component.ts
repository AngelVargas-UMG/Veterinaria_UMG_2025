import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MascotasComponent } from './mascotas/mascotas.component';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, MascotasComponent],
  template: `
    <div class="min-h-screen bg-gray-100 flex items-center justify-center p-4">
      <app-mascotas></app-mascotas>
    </div>
  `
})
export class AppComponent {
  title = 'mi-veterinaria';
}
