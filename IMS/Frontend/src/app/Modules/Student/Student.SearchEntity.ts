import { FilterEntity } from "../Filter.Entity";

export class SearchStudentEntity extends FilterEntity {
  StudentName: string;

  constructor(Student: any = null) {
    super(Student);
    this.StudentName = Student == null ? null : Student.StudentName;
  }

}
