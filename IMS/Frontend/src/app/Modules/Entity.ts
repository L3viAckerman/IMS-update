export class Entity {
  Id: string = '00000000-0000-0000-0000-000000000000';
  IsEdit: boolean = false;
  IsSelected: boolean = false;
  IsActive: boolean = false;

  constructor() {

  }

  Clone(): Entity {
    return JSON.parse(JSON.stringify(this));
  }
  Apply(Entity: Entity) {
    
  }
}

