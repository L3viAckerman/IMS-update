import { FilterEntity } from "../Filter.Entity";
// Search Entity này chưa xong, cần xác định phương thức tìm kiếm theo trường nào?
export class SearchInternReportEntity extends FilterEntity {
  LecturerId: string = null;
  CourseId: string = null;
  constructor() {
    super();
  }

}
