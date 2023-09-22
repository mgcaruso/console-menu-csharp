class EstudiantePrimaria : Estudiante{

    string grado;
    char seccion;
    public EstudiantePrimaria(int id, string nombre, int edad, string grado, char seccion): base(id,nombre, edad){
        this.grado = grado;
        this.seccion = seccion;    
    }

    public override string ToString()
    {
        return base.ToString() + $"Grado: {grado}. Seccion: {seccion} ";
    }
}