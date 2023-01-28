import { Inject } from "@angular/core";
import { MatDialogRef, MAT_DIALOG_DATA } from "@angular/material/dialog";


export class DialogBase<DiaglogType> {
    constructor( public dialogRef: MatDialogRef<DiaglogType>){
            
        }

        close(): void {
            this.dialogRef.close();
          }
        
}
