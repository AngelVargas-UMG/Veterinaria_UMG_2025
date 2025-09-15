import { ChangeDetectionStrategy, Component, OnInit, signal } from '@angular/core';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';

interface Usuario {
  usuarioID: number;
  nombre: string;
  apellido: string;
  email: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, HttpClientModule],
  template: `
    <div class="flex flex-col items-center justify-center min-h-screen bg-gray-100 p-4 font-inter">
      <div class="w-full max-w-4xl p-8 bg-white rounded-lg shadow-xl border border-gray-200">
        <h1 class="text-4xl font-extrabold text-center text-gray-800 mb-2">Sistema de Gestión de Veterinaria</h1>
        <p class="text-center text-gray-500 mb-8">Frontend desarrollado con Angular y Tailwind CSS.</p>

        <!-- Sección de listado de usuarios -->
        <div class="bg-gray-50 p-6 rounded-lg border border-gray-100 mb-8">
          <h2 class="text-2xl font-bold text-gray-700 mb-4">Usuarios Registrados</h2>
          <div *ngIf="loading()" class="text-center text-gray-500">Cargando usuarios...</div>
          <div *ngIf="!loading() && usuarios().length === 0" class="text-center text-gray-500">No se encontraron usuarios.</div>
          <ul class="space-y-4">
            <li *ngFor="let user of usuarios()" class="flex items-center justify-between p-4 bg-white rounded-md shadow-sm hover:shadow-md transition-shadow">
              <div class="flex-1">
                <div class="font-semibold text-gray-800">{{ user.nombre }} {{ user.apellido }}</div>
                <div class="text-sm text-gray-500">{{ user.email }}</div>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  `,
  styles: [`
    @import url('https://fonts.googleapis.com/css2?family=Inter:wght@400;600;700;800&display=swap');

    body {
      font-family: 'Inter', sans-serif;
    }
    .custom-shadow {
      box-shadow: 0 4px 6px -1px rgba(0, 0, 0, 0.1), 0 2px 4px -1px rgba(0, 0, 0, 0.06);
    }
  `],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class App implements OnInit {
  usuarios = signal<Usuario[]>([]);
  loading = signal(true);
  private apiUrl = 'http://localhost:8080/api/Usuarios'; // La URL del backend API

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.fetchUsuarios();
  }

  fetchUsuarios() {
    this.http.get<Usuario[]>(this.apiUrl).subscribe({
      next: (data) => {
        this.usuarios.set(data);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los usuarios', err);
        this.loading.set(false);
      }
    });
  }
}
