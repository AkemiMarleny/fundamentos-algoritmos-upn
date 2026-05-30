def calcolare_imc(peso: float, altezza: float) -> float:
    return peso / (altezza * altezza)


def diagnosi(imc: float) -> None:
    if imc < 18.5:
        print("Bajo peso")
    elif imc >= 18.5 and imc < 25.0:
        print("Peso normal")
    elif imc >= 25.0 and imc < 30.0:
        print("Sobrepeso")
    else:
        print("Obesidad")


def validare_input(messaggio: str) -> float:
    try:
        valore_letto: float = float(input(f"{messaggio}: "))
        if valore_letto <= 0:
            return validare_input(messaggio)

        return valore_letto
    except ValueError:
        print("Entrada inválida. Por favor, ingrese un valor válido")
        return validare_input(messaggio)


print("CALCULADORA DE IMC CON DIAGNÓSTICO")

peso: float = validare_input("Ingrese su peso en kg: ")
altezza: float = validare_input("Ingrese su altura en metros: ")

imc: float = calcolare_imc(peso, altezza)

diagnosi(imc)
print(f"Tu IMC es {imc:.2f}")
