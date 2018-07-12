import { FilterEntity } from "../Filter.Entity";

export class SearchOperationEntity extends FilterEntity
{
  Name: string;
  constructor(OperationEntity: any = null) {
    super(OperationEntity);
    this.Name = OperationEntity === null ? null : OperationEntity.Name;
    }
}
