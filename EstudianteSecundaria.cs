class EstudianteSecundaria : Estudiante
{

    string anio;
    int cursosAprobados;
    public EstudianteSecundaria(int id, string nombre, int edad, string anio, int cursosAprobados): base(id,nombre, edad){
        this.anio = anio;
        this.cursosAprobados = cursosAprobados;    
    }

    public override string ToString()
    {
        return base.ToString() + $"Año: {anio}. Cantidad cursos aprobados: {cursosAprobados} ";
    }
}