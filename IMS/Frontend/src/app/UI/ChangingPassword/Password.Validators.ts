import { AbstractControl } from "@angular/forms/src/model";

export class PasswordMatchValidators
{
  static passwordMatch(firstCtrlName, secondCtrlName)
  {
    return (control: AbstractControl) => {
      let firstName = control.get(firstCtrlName).value;
      let secondName = control.get(secondCtrlName).value;
      if (firstName !== secondName) return { passwordMatch: false };
      else return null;
    };
  }
}
