
def RLE():
    print("Введите строку для RLE(пример: 10h,C0h(145),56h,D8h,7Ah(54))")
    vhod_ = input()
    vhod = vhod_.split(",")

    vuhod = []

    deistvie = 1
    for bait in vhod:
        if ('(' in bait):
            print("")
            print("Действие: " + str(deistvie) + ", число: " + str(bait))

            start_index = bait.find('(')
            end_index = bait.find(')')
            chislo = bait[:start_index]  # строка до скобки
            count = int(bait[start_index + 1:end_index])  # строка внутри скобок, преобразованная в число
            count = int(count)
            if count > 63:
                print("Количество раз больше 63")

                k = int(count / 63)
                n = count % 63
                print(str(count) +" = 63 * " + str(k) + " + " + str(n))
                result1 = "(FFh, " + str(chislo) + ")"
                print("Выводим " + str(k) + " раз" + str(result1))
                for i in range(0, k):
                    vuhod.append(result1)
                binary_number = bin(n)[2:]
                print("Исходное число в двоичной системе: " + str(binary_number))
                while len(binary_number) < 6:
                    binary_number = '0' + binary_number
                print("Число дополненное 0 до 6 разрядов: " + str(binary_number))

                while len(binary_number) < 8:
                    binary_number = '1' + binary_number
                print("Число дополненное 1 до 8 разрядов: " + str(binary_number))

                hex_number = hex(int(binary_number, 2))[2:]
                print("Это двоичное число в шестнадцатеричной: " + str(hex_number.upper()))

                result2 = "(" + str(hex_number).upper() + 'h' + ", " + str(chislo) + ")"
                vuhod.append(result2)
                print("Результат: " + result2)



            else:
                print("Количество раз меньше 63")

                binary_number = bin(count)[2:]
                print("Исходное число в двоичной системе: " + str(binary_number))
                while len(binary_number) < 6:
                    binary_number = '0' + binary_number
                print("Число дополненное 0 до 6 разрядов: " + str(binary_number))

                while len(binary_number) < 8:
                    binary_number = '1' + binary_number
                print("Число дополненное 1 до 8 разрядов: " + str(binary_number))

                hex_number = hex(int(binary_number, 2))[2:]
                print("Это двоичное число в шестнадцатеричной: " + str(hex_number.upper()))

                result = "(" + str(hex_number).upper() + 'h' + ", " + str(chislo) + ")"
                vuhod.append(result)
                print("Результат: " + result)

        else:
            print("")
            print("Действие: " + str(deistvie) + ", число: " + str(bait))
            bait = bait.rstrip('h')
            binary_number = bin(int(bait, 16))[2:]
            print("Исходное число в двоичной системе: " + str(binary_number))
            while len(binary_number) < 8:
                binary_number = '0' + str(binary_number)
            print("Дополнение до 8 разрядов:" + str(binary_number))

            if (binary_number[:2] == "11"):
                print("Старшие два разряда = 11")
                result = "(C1h, " + str(bait) + 'h' + ")"
                vuhod.append(result)
                print("Результат: " + result)

            else:
                print("Старшие два разряда != 11, следовательно, переписываем в выходноц поток без изменений")
                vuhod.append(bait + 'h')
                print("Результат: " + bait + 'h')

        deistvie += 1
    print("")
    print("Выход: " + str(vuhod))


def RLE_decode():
    print("Введите закодированную строку для декодирования(например: 45h;(FFh,11h);(F0h,11h);7Ah;(C1h,F0h);(FFh,85h);(D6h,85h))")
    vhod_ = input()
    vhod = vhod_.split(";")

    vuhod = []
    needCode = False
    FFh_count = 0

    for bait in vhod:
        print()
        print("Рассматриваем: " + str(bait))
        if '(' in bait:
            # Декодирование закодированной последовательности
            start_index = bait.find('(')
            end1_index = bait.find(',')
            end_index = bait.find(')')

            hex_code = bait[start_index + 1:end1_index - 1]
            if hex_code == 'FF':
                if FFh_count == 0:
                    print("В начале FFh, следовательно, L > 63")
                x = bait[end1_index + 1:end_index]
                needCode = True
                FFh_count += 1
                print("Количество скобок с FFh = " + str(FFh_count))
                continue
            elif hex_code == 'C1':
                print("В начале C1h, следовательно, старший разряд 11. Значит исходное число после запятой")
                x = bait[end1_index + 1:end_index]
                print("Результат: " + str(x))

                vuhod.append(str(x))
            elif needCode:
                print("Скобка после FFh показывает количество повторений")
                hex_code = bait[start_index + 1:end1_index - 1]
                print("Число в шестнадцатеричной: " + str(hex_code) + "h")
                binary_number = bin(int(hex_code, 16))[2:]
                print("Число в двоичной: " + str(binary_number))
                necessary_binary_number = binary_number[2:]
                print("Число в двоичной без 2 старших разрядов: " + str(necessary_binary_number))
                decimal_number = int(necessary_binary_number, 2)
                print("N = " + str(decimal_number))
                print("K = " + str(FFh_count) + " , т.к. скобка с FFh повтирилась " + str(FFh_count) + " раз")
                count = FFh_count * 63 + decimal_number
                print("L = 63 * " + str(FFh_count) + " + " + str(decimal_number)+ " = " + str(count))
                FFh_count = 0
                print("Исходное число: " + str(x))
                vuhod.append(str(x) + ", ... , " + str(x) + "(" + str(count) + " раз)")
                print("Результат: " + str(x) + ", ... , " + str(x) + "(" + str(count) + " раз)")
                needCode = False
            else:
                print("В начале нет FFh, скобка не стоит после FFh, C1h, следовательно, L <= 63. Значит исходное число после запятой")
                print("Рассчет количества повторений:" )
                hex_code = bait[start_index + 1:end1_index - 1]
                print("Число в шестнадцатеричной: " + str(hex_code) + "h")
                binary_number = bin(int(hex_code, 16))[2:]
                print("Число в двоичной: " + str(binary_number))
                necessary_binary_number = binary_number[2:]
                print("Число в двоичной без 2 старших разрядов: " + str(necessary_binary_number))
                count = int(necessary_binary_number, 2)
                print("N = " + str(count))
                x = bait[end1_index + 1:end_index]
                print("Исходное число: " + str(x))
                vuhod.append(str(x) + ", ... , " + str(x) + "(" + str(count) + " раз)")
                print("Результат: " + str(x) + ", ... , " + str(x) + "(" + str(count) + " раз)")
                needCode = False


        else:
            print("Нет скобки, значит старший разряд != 11. Это число является исходным")
            # Простое добавление символов в выходную последовательность
            vuhod.append(bait)
            print("Результат: " + str(bait))

    # Объединение выходной последовательности
    decoded_string = ','.join(vuhod)
    print("Результат декодирования: " + decoded_string)

# 10h;(FFh,C0h);(FFh,C0h);(D3h,C0h);56h;(C1h,D8h);(F6h,7Ah)



def LZV():
    print("Введите строку для LZV(пример: AAABAABAABA)")

    dicts = {'A': 65, 'B': 66}

    vhod = input()
    print("{:<10s} {:<5s} {:<15s} {:<10s} {:<12s}".format("cur_str", "c", "code", "indexes", "sodershimoe"))


    indexes = "0...255"
    sodershimoe = "ASCII"

    vuhod = []
    vuhod.append(256)

    curStr = ''

    c = "--"
    code = "--"

    print("{:<10s} {:<5s} {:<15s} {:<10s} {:<12s}".format("''", str(c), str(code), str(indexes), str(sodershimoe)))
    print("{:<10s} {:<5s} {:<15s} {:<10s} {:<12s}".format('', '', '', "256", "ClearCode"))
    print("{:<10s} {:<5s} {:<15s} {:<10s} {:<12s}".format('', '', '', "257", "EndOfFile"))

    count = 0
    for i in vhod:
        c = i
        if curStr + c in dicts:
            curStr = curStr + c
            print("{:<10s} {:<5s} {:<15s}".format(str(curStr), str(c), "--"))
        else:
            code = dicts.get(curStr)
            vuhod.append(code)
            count += 1
            sodershimoe = curStr + c
            dicts[curStr + c] = 257 + count
            indexes = 257 + count
            curStr = c
            print("{:<10s} {:<5s} {:<15s} {:<10s} {:<12s}".format(str(curStr), str(c), str(code), str(indexes), str(sodershimoe)))

    code = dicts.get(curStr)
    print("{:<10s} {:<5s} {:<15s} {:<10s} {:<12s}".format('', '', str(code), '', ''))
    vuhod.append(code)
    vuhod.append(257)
    print("Выход:" + str(vuhod))



def LZV_decode():
    print("Введите строку для декодировани LZV(пример: 256,65,258,66,259,261,257)")

    dicts = {65: 'A', 66: 'B', 256: "ClearCode", 257: "EndOfFile"}



    vhod_ = input()
    vhod = vhod_.split(",")

    print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format("cur_str", "c", "x", "code", "indexes", "sodershimoe"))

    vuhod = []
    curStr = ""
    c = ""
    x = ""
    code = ""

    indexes = "0...255"
    sodershimoe = "ASCII"

    print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format('', '', '', '', str(indexes), sodershimoe))
    print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format('', '', '', '', "256", "ClearCode"))
    i = 0
    code = vhod[i]
    i += 1



    print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format(curStr, c, x, code, "257", "EndOfFile"))
    code = vhod[i]
    i += 1


    count = 0


    if code != 257 and i != len(vhod):
        curStr = dicts.get(int(code))
        print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format(curStr, c, x, str(code), "", ""))
        vuhod.append(curStr)
        code = int(vhod[i])
        while code != 257:
            if code in dicts:
                x = dicts.get(code)
                c = x[0]
                vuhod.append(x)
                count += 1
                sodershimoe = curStr + c
                indexes = 257 + count
                dicts[indexes] = curStr + c
                curStr = x
                print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format(curStr, c, x, str(code), str(indexes), sodershimoe))

            else:
                c = ""
                x = curStr + curStr[0]
                vuhod.append(x)
                count += 1
                sodershimoe = x
                indexes = 257 + count
                dicts[indexes] = x
                curStr = dicts.get(code)
                print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format(curStr, c, x, str(code), str(indexes), sodershimoe))

            i += 1
            code = int(vhod[i])

    print("{:<10s} {:<5s} {:<5s} {:<15s} {:<10s} {:<12s}".format('', '', '', str(code), '', ''))
    print("Выход:" + str(vuhod))





# AAABAABAABA
# CACCAACCAAA




print("1 - RLE, 2 - декодирование RLE, 3 - LZV, другое - декодирование LZV")
zadanie = input()
if int(zadanie) == 1:
    RLE()
elif int(zadanie) == 2:
    RLE_decode()
elif int(zadanie) == 3:
    LZV()
else:
    LZV_decode()


# 10h,C0h(145),56h,D8h,7Ah(54)
# 45h,11h(111),7Ah,F0h,85h(85)