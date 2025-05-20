# Angular + C# Self-Contained Application

Гибридное приложение, объединяющее Angular для фронтенда и C# (Kestrel) для бэкенда в единый исполняемый файл.

## 🚀 Быстрый старт

### 1. Инициализация проекта
```bash
# Создание Angular-проекта (без глобальной установки)
npx -p @angular/cli ng new MyAngularApp
cd MyAngularApp

# Установка зависимостей Angular
npm install

# сборка проекта
dotnet publish -c Release -r win-x64 --self-contained true
npm run build
