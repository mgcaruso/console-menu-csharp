class Estudiante
{
    // Cada estudiante tiene un nombre, un número de identificación único y una edad. Además, se requiere registrar información adicional dependiendo de si el estudiante es de primaria o secundaria. Para los estudiantes de primaria, se debe registrar el grado en el que están y la sección a la que pertenecen (por ejemplo, "4to A"). Para los estudiantes de secundaria, se debe registrar el año en el que están y el número de cursos aprobados.
    protected int id;
    protected string nombre;
    protected int edad;

    public Estudiante(int id, string nombre, int edad)
    {
        this.id = id;
        this.nombre = nombre;
        this.edad = edad;
    }

    public int getId(){
        return id;
    }
    public override string ToString(){
        return $"ID: {id}. Nombre: {nombre}. Edad: {edad}. ";
    }
}