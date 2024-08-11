export interface UsuarioDTO {
  Id ?: string;
  guid?: string;
  userName: string;
  name: string;
  correo: string;
  profesionId: number; // El signo de interrogación indica que es opcional
}
