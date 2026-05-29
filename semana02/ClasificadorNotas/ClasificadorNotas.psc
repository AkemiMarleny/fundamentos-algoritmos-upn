Algoritmo ClasificadorNotas
    Definir voto Como Real
    
    Escribir "=== CLASIFICADOR DE NOTAS ==="
    Escribir "Ingrese la nota del estudiante: "
    Leer voto
    
    ClasificarNota(voto)
    
FinAlgoritmo

Subproceso ClasificarNota(voto)
    
    Si voto < 0 O voto > 20 Entonces
        Escribir "Error: La calificación debe estar comprendida entre 0 y 20."
    Sino
        Si voto = 20 Entonces
            Escribir "Nota ", voto, ": Excelente"
        Sino
            Si voto >= 11 Entonces
                Escribir "Nota ", voto, ": Aprobado"
            Sino
                Escribir "Nota ", voto, ": Desaprobado"
            FinSi
        FinSi
    FinSi
FinSubproceso