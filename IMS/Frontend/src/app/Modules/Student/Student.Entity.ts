import { Entity } from "../Entity";

export class StudentEntity extends Entity {
  Class: string = null;
  Department: string = null;
  Address: string = null;
  FullName: string = null;
  Birthday: string = null; 
  Gpa: string = null;
  Vnumail: string = null;
  GraduationYear: string = null;
  PersonalMail: string = null;
  Skype: string = null;
  Facebook: string = null;
  Phone: string = null;
  LanguageSkill: string = null;
  constructor(User: any = null) {
    super();
    this.IsEdit = false;
    this.IsActive = false;
    this.IsSelected = false;
  }
}



