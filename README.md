# Café-Café
Café-Café es una aplicación de escritorio para Windows escrita en C# que no permite que el sistema entre en suspensión o se bloquee la sesión del usuario, mediante la simulación de la presión de la tecla F15.

## Timer de simulador de teclado
En la línea 63 del archivo Form1.cs es posible modificar el tiempo en milisegundos del timer que dispara el evento de la tecla.
```
timer1.Interval = 60000; //Un minuto
```

## Timer para apagado automático
Se agregó feature para programar un apagado automático indicando un tiempo en minutos.

## Observaciones
Si bien la tecla F15 no debería interferir en casi nada de lo que hagamos, en algunos terminales retorna el caracter '~', por lo que no recomiendo el uso de esta aplicación si utilizamos una shell.
