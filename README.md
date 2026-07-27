# sysadmin-inventory

[![C#](https://shields.io)](https://microsoft.com)
[![Avalonia](https://shields.io)](https://avaloniaui.net)
[![EF Core](https://shields.io)](https://microsoft.com)

> Десктопное приложение для системного администратор. Учет техники, заметки и другое. (компьютеры, серверы, принтеры, периферия и.т.д).

## Стек технологий

* **UI Фреймворк:** Avalonia UI 
* **Архитектура:** MVVM с использованием ReactiveUI
* **Язык программирования:** C# (.NET 10)
* **База данных:** SQLite (Локальная БД)
* **ORM:** Entity Framework Core

## [Загрузка последней версии](https://github.com/KramSany/sysadmin-inventory/releases/tag/v2.7.0)

## Сборка

1. Требования
* Установленный [.NET SDK](https://microsoft.com) актуальной версии.
* Среда разработки Rider или Visual Studio 2022 с расширением Avalonia.

2. Быстрый старт

 Склонируйте репозиторий:
   ```bash
   git clone https://github.com](https://github.com/KramSany/sysadmin-inventory.git
   ```

## Основные сущности системы (Models)

* **Устройства:** `Computer`, `Server`, `ServerRack`, `Printer`, `Peripheral`, `Cartridge`, `Phone`, `Monitor`.
* **Администрирование:** `User`, `AppSetting`, `TaskEntity`.
* **Безопасность:** `PasswordEntity`, `Rutoken`.

## Лицензия и благодарность

Этот проект распространяется под лицензией MIT. Подробности в файле `LICENSE`.

### Благодарности
Отдельная благодарность **DIMANRUS**, чей проект был взят за основу. 

Все последующие коммиты и изменения в данном репозитории созданы разработчиком **KRAMSANY** с целью улучшения, обновления архитектуры и устранения ошибок.
