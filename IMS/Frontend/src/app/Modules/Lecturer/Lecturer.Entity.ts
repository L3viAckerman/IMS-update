import {Entity } from "../Entity";

export class LecturerEntity extends Entity {
    Id : string = null;
    Phone: string = null;
    Vnumail : string = null;
    Gmail : string = null;
    Note: string = null;
    Fullname: string = null;
    constructor (LecturerEntity? : any){
        super();
        this.IsEdit = false;
        this.IsActive = false;
        this.IsSelected = false;
    }
}
