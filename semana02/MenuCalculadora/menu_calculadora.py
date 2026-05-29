def main():
    print("MENÚ DE CALCULADORA")

    operazione: int = leggere_operazione()

    num1: float = leggere_numero("Ingrese el primer número")
    num2: float = leggere_numero("Ingrese el segundo número")

    processa_operazione(num1, num2, operazione)


def leggere_operazione() -> int:
    print("\nSeleccione la operación:")
    print("1. Suma")
    print("2. Resta")
    print("3. Multiplicación")
    print("4. División\n")

    try:
        opzione: int = int(input("Opción: "))
        if opzione < 1 or opzione > 4:
            print("Opción no válida. Por favor, seleccione una opción del 1 al 4.")
            return leggere_operazione()

        return opzione
    except ValueError:
        print("Opción no válida. Por favor, seleccione una opción del 1 al 4.")
        return leggere_operazione()


def leggere_numero(messaggio: str) -> float:
    try:
        valore_letto: float = float(input(f"{messaggio}: "))
        return valore_letto
    except ValueError:
        print("Entrada no válida. Por favor, ingrese un número.")
        return leggere_numero(messaggio)


def processa_operazione(num1: float, num2: float, operazione: int):
    try:
        risultato: float = eseguire_operazione(num1, num2, operazione)
        print(
            f"Resultado: {num1} {operatore_matematico(operazione)} {num2} = {risultato:.2f}"
        )
    except ZeroDivisionError:
        print("Número no válido. Por favor, ingrese un número mayor a 0")
        divisore: float = leggere_divisore()
        risultato: float = eseguire_operazione(num1, divisore, operazione)
        print(
            f"Resultado: {num1} {operatore_matematico(operazione)} {divisore} = {risultato:.2f}"
        )


def eseguire_operazione(num1: float, num2: float, operazione: int) -> float:
    match operazione:
        case 1:
            return num1 + num2
        case 2:
            return num1 - num2
        case 3:
            return num1 * num2
        case 4:
            return dividere(num1, num2)
        case _:
            raise ValueError


def operatore_matematico(operazione: int) -> str:
    match operazione:
        case 1:
            return "+"
        case 2:
            return "-"
        case 3:
            return "*"
        case 4:
            return "/"
        case _:
            raise ValueError


def dividere(dividendo: float, divisore: float) -> float:
    if divisore == 0:
        raise ZeroDivisionError

    return dividendo / divisore


def leggere_divisore() -> float:
    divisore: float = leggere_numero("Ingrese el segundo número: ")
    if divisore == 0:
        return leggere_divisore()

    return divisore


main()
