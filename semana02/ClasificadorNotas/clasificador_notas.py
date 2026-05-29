def classificare_voto(voto: float) -> None:
    if voto < 0 or voto > 20:
        print("Error: La calificación debe estar comprendida entre 0 y 20.")

    elif voto == 20:
        print("Excelente")

    elif voto >= 11:
        print("Aprobado")

    else:
        print("Desaprobado")


print("CLASIFICADOR DE NOTAS")

try:
    voto: float = float(input("Ingrese la nota del estudiante: "))
    classificare_voto(voto)

except:
    print("Entrada no válida. Ingrese un número.")
