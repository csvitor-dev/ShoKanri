<p align="center">
    <picture>
        <source srcset="./Docs/Assets/Svg/kanri-light.svg" media="(prefers-color-scheme: dark)" width="200" alt="logo dark theme">
        <source srcset="./Docs/Assets/Svg/kanri-dark.svg" media="(prefers-color-scheme: light)" width="200" alt="logo light theme">
        <img src="./Docs/Assets/Svg/kanri-dark.svg" width="200" alt="logo dark theme as default">
    </picture>
</p>

<br/>

# 📊 Shō-Kanri API | Sample API based on the [_Kanri_](https://github.com/An-Ordinary-Software-Engineering/Kanri.Backend) project

> [!NOTE]\
> **Shō-Kanri** (or rather, _小規模な管理_ **Shōkibona Kanri**) comes from Japanese and means "small-scale management",
> because it is a small sample of the `@An-Ordinary-Software-Engineering/Kanri.Backend` project's API.

---

## Development Flow

Whenever you are going to perform a task associated with an **Issue**, create a new _branch_:

```bash
git checkout -b prefix/your-branch-name
```

When finished, create a **Pull Request** for the **`develop`** _branch_!

> [!TIP]\
> It is important to follow these conventions, as the execution of certain operations will be restricted by predefined
> "[**rulesets**](https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-rulesets/creating-rulesets-for-a-repository)"
> in the `main` branch.

## Project Structure

```text
├── Docs/
├── Library/
│   ├── ShoKanri.Exception/
│   └── ShoKanri.Http/
│
├── Source/
│   ├── Core/
│   │   ├── ShoKanri.Application/
│   │   └── ShoKanri.Domain/
│   │ 
│   ├── Infrastructure/
│   │   ├── ShoKanri.DAO/
│   │   └── ShoKanri.IoC/
│   │
│   └── Presenter/
│       └── ShoKanri.API/
│
└── Test/
    ├── ShoKanri.Domain.Unit/
    └── ShoKanri.Mock/
```

> This is the target structure of the project
