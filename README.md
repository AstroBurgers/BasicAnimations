# BasicAnimations Documentation


## `CustomAnimations.json` Documentation  

---

## Root Structure

```json
{
  "animations": [ /* List of custom animations */ ],
  "scenarios": [ /* List of custom scenarios */ ]
}
```

---

## `animations` Array

An array of custom **complex animations** composed of intro, main, and outro stages.

### Example

```json
{
  "menuName": "Bench Sit",
  "introDict": "amb@world_human_picnic@male@enter",
  "introName": "enter",
  "mainDict": "anim@amb@business@bgen@bgen_no_work@",
  "mainName": "sit_phone_phoneputdown_idle_nowork",
  "outroDict": "get_up@sat_on_floor@to_stand",
  "outroName": "getup_0",
  "looped": true,
  "canPlayerMove": false,
  "stayInEndFrame": false,
  "stayInEndFrameTime": 0,
  "stayInEndFrameStage": "None",
  "keybind": "NumPad1"
}
```

### Fields

| Field               | Type     | Required | Description |
|--------------------|----------|----------|-------------|
| `menuName`         | string   | ✅        | Display name in the in-game menu. |
| `introDict`        | string   | ⛔        | Dictionary for the intro animation. Leave empty if unused. |
| `introName`        | string   | ⛔        | Animation name from the intro dictionary. |
| `mainDict`         | string   | ⛔        | Dictionary for the main animation. |
| `mainName`         | string   | ⛔        | Animation name for the main dictionary. |
| `outroDict`        | string   | ⛔        | Dictionary for the outro animation. |
| `outroName`        | string   | ⛔        | Name for the outro animation. |
| `looped`           | boolean  | ✅        | Whether the main animation loops. |
| `canPlayerMove`    | boolean  | ✅        | Allow movement during animation. |
| `stayInEndFrame`   | boolean  | ✅        | Whether to freeze on the final frame. |
| `stayInEndFrameTime` | integer | ✅        | Time in milliseconds to freeze. |
| `stayInEndFrameStage` | `"Start"` \| `"Main"` \| `"End"` \| `"None"` | ✅ | Which stage freezes. |
| `keybind`          | string   | ⛔        | Optional key to trigger (e.g., `"F1"`, `"NumPad1"`). |

---

## `scenarios` Array

An array of **built-in GTA scenario** entries.

### Example

```json
{
  "scenarioName": "world_human_smoking",
  "menuName": "Smoke",
  "keybind": "NumPad2"
}
```

### Fields

| Field         | Type   | Required | Description |
|---------------|--------|----------|-------------|
| `scenarioName`| string | ✅        | GTA scenario name (e.g. `world_human_smoking`). |
| `menuName`    | string | ✅        | Display name in the menu. |
| `keybind`     | string | ⛔        | Optional keybind (e.g., `"F3"`, `"NumPad2"`). |

---

## Valid Keybind Values

You can use any key from `System.Windows.Forms.Keys`, including:

- `"NumPad1"` to `"NumPad9"`
- `"F1"` to `"F12"`
- `"A"` through `"Z"`
- `"LShiftKey"`, `"ControlKey"`, etc.

> Only one animation/scenario will fire if multiple share the same key. Duplicates are not validated.

---

## Troubleshooting

| Symptom | Cause | Fix |
|--------|-------|-----|
| Animation doesn't play | Incorrect dict/name or animation blocked | Verify animation names in OpenIV and check ped state |

---

## Tips

- Use `looped: true` with `stayInEndFrame` for idle animations like sitting.
- You can skip `intro` or `outro` if not needed.
- Animations can still be played from the menu even if no `keybind` is defined.
- Hold poses using `stayInEndFrameTime` and `stayInEndFrameStage`.
