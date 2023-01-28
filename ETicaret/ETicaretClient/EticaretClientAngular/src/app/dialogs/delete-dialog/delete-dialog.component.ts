import { Component,Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogBase } from '../dialog-base';

@Component({
  selector: 'app-delete-dialog',
  templateUrl: './delete-dialog.component.html',
  styleUrls: ['./delete-dialog.component.css']
})
export class DeleteDialogComponent extends DialogBase<DeleteDialogComponent> {

  constructor(
     dialogRef: MatDialogRef<DeleteDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public  data: DeleteState,
  )
   {
    super(dialogRef);
  }
 

}

export enum DeleteState{
  Yes,No
}