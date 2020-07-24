# TestCode

**ThreadingSampleA** 
Этот тест показывает что если мы создаем поток, то ошибка в этом 
потоке может привести к поломке всего приложения. Для того, чтобы исправить 
ситуацию достаточно обработать исключение в созданном потоке.


**ThreadingSampleB**
Этот тест показывает как можно сделать паузу в ходе выполнения программы.
Описано два способа, первый приводит к проблемам с производительностью, второй нет.
Это вызвано тем что во втором случае выполняющй поток не блокируется и продолжает делать полезную работу.


**ThreadingSampleC**
Этот тест показывает что работа с одними и теми же данными из двух потоков может привести к ошибке.
Чтобы исправить это можно использовать ключевое слово lock. 
В этом случае работа с данными будет происходить последовательно, а не паралельно. 

**ThreadingSampleD**
Этот тест показывает что при создании задачи в C# поток продолжает выполнение не дожидаясь завершения созданной задачи.
Чтобы исправить это необходимо использовать ключевое слово await. 


**ThreadingSampleE**
Этот тест показывает что при использовании вложенных конструкций lock в C# может возникнуть проблема взаимной блокировки.
Чтобы исправить это достаточно блокировать значения в одном и том же порядке, а лучше по возможности избегать вложенных блокировок. 
