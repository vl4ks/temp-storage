![UseCase]()

# Классы

## 1.1. Account (Абстрактный)
**Описание:** Базовый класс для всех пользователей системы.

**Поля:**
- `id` – уникальный идентификатор
- `login`, `password` – данные для входа
- `role` – тип учетной записи (`USER`, `ADMIN`, `GOVERNMENT_SERVANT`)

**Методы:**
- Стандартные геттеры/сеттеры (на диаграмме не указаны)

**Связи:**
- Родитель для `User`, `Admin`, `GovernmentServant` (наследование)
- Использует `AccountRole` (зависимость)

---

## 1.2. User
**Описание:** Пользователь, подающий заявки.

**Поля (дополнительно к Account):**
- **Личные данные:**
  - `name` - ФИО в строковом формате
  - `birthDate` - дата рождения
  - `purpose` - цель визита
  - `phoneNumber` - номер телефона
  - `citizenship` - гражданство
  - `passport` - серия и номер паспорта в строковом формате
  - `email` - адрес эл. почты
  - `inn` - номер ИНН

**Методы:**
- `submitApplication()` – создает новую заявку
- `updateProfile()` – редактирует данные

**Связи:**
- Агрегация с `Application` (у пользователя может быть много заявок)

---

## 1.3. GovernmentServant
**Описание:** Госслужащий, обрабатывающий заявки.

**Поля (дополнительно к Account):**
- `department` – отдел, в котором работает

**Методы:**
- `processApplication()` – меняет статус заявки
- `addComment()` - добавляет комментарий

**Связи:**
- Агрегация с `Application`

---

## 1.4. Admin
**Описание:** Администратор, управляющий услугами и правилами.

**Методы:**
- `createService()` – добавляет новую услугу
- `addRuleToService()` - метод для связи правила с услугой

**Связи:**
- Агрегация с `Service` и `Rule`

---

## 1.5. Application
**Описание:** Заявка на услугу.

**Поля:**
- `applicationId` - уникальный идентификатор
- `status` – текущий статус (`PENDING`, `APPROVED`, `REJECTED`, `IN_PROGRESS`)
- `comment` – комментарий госслужащего
- `subDate`, `execDate` – даты подачи и исполнения
- `user` – указывает, какой пользователь подал заявку
- `service` – определяет, на какую услугу подана заявка

**Связи:**
- Композиция с `Service` (заявка не существует без услуги)
- Агрегация с `User` (заявка принадлежит пользователю)
- Использует `ApplicationStatus` (зависимость)

---

## 1.6. Service
**Описание:** Услуга, на которую подается заявка.

**Поля:**
- `name`, `description` – название и описание услуги
- `period` - период действия услуги в днях
- `rules` – список правил для получения услуги

**Связи:**
- Агрегация с `Rule` (услуга содержит правила)

---

## 1.7. Rule
**Описание:** Правило для получения услуги.

**Поля:**
- `description` - описание правила
- `parameter`, `checkParameter` – условия проверки
- `compOperator` – оператор сравнения

**Методы:**
- `validate()` – проверяет соответствие правилу

---

# 2. Классы полного цикла

## 2.1. Репозитории
### **UserRepository**

**Методы:**
- `save()`, `findById()`, `findByLogin()`, `findAll()`, `delete()`.

**Связь:** Агрегация c `User`.

### **ApplicationRepository**

**Методы:**
- `findById()`, `findByUser()`, `findByStatus()`, `updateStatus()`.

**Связь:** Агрегация c `Application`.

---

## 2.2. Сервисы
### **AuthService**

**Поля:**
- `userRepository` - для взаимодействия с репозиторием

**Методы:**
- `authenticate()` - для входа в аккаунт
- `getUserRole()` - для получения роли пользователя

**Связь:** Композиция с `UserRepository`.

### **ApplicationProcessingService**

**Поля:**
- `applicationRepository` - для взаимодействия с репозиторием

**Методы:**
- `processApplication()` – выполняет действие по заявке (одобрить/отклонить)
- `setStatus()` - устанавливает статус заявки
- `addComment()` - добавляет комментарий

**Связь:** Композиция с `ApplicationRepository`.

---

## 2.3. Контроллеры (API)
### **UserController**
**Эндпоинты:**
- `POST /register` – регистрация нового пользователя
- `GET /profile` – получение данных пользователя
- `POST /applications` – подача заявки
- `GET /applications` – список заявок пользователя

**Связь:** Композиция с `AuthService` и `ApplicationProcessingService`.

### **GovernmentServantController**
**Эндпоинты:**
- `PUT /applications/{id}/status` – изменение статуса заявки
- `POST /applications/{id}/comment` – добавление комментария
- `GET /applications/pending` – список заявок в статусе "ожидает решения"

**Связь:** Композиция с `ApplicationProcessingService`.

### **AdminController**
**Эндпоинты:**
- `POST /services` – создание новой услуги
- `PUT /rules` – добавление/изменение правил
- `GET /users` – список всех пользователей

**Связь:** Композиция с `ServiceRepository`.

---

# 3. Перечисления (Enums)
### **AccountRole**
**Роли:**
- `USER`, `ADMIN`, `GOVERNMENT_SERVANT`

### **ApplicationStatus**
**Статусы заявок:**
- `PENDING` - заявка только что создана и ожидает первичного рассмотрения
- `APPROVED` - одобрена
- `REJECTED` - отклонена
- `IN_PROGRESS` - заявка взята в работу, но ещё не завершена

### **Action**
**Действия над заявкой:**
- `APPROVE` - одобрить
- `REQUEST_CHANGE` - запросить изменения
- `REJECT` - отклонить

**Связи:** Зависимости в `AuthService`, `ApplicationProcessingService`.