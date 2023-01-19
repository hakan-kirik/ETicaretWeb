
import { Directive, ElementRef, EventEmitter, HostListener, Input, Output, Renderer2 } from '@angular/core';
import { AlertifyService, MessageType, Position } from 'src/app/services/admin/alertify.service';
import { ProductService } from 'src/app/services/common/models/product.service';

declare var $:any;

@Directive({
  selector: '[appDelete]'
})
export class DeleteDirective {

  constructor(
    private element:ElementRef,
    private _renderer:Renderer2,
    private productService:ProductService,
    private alertifyService:AlertifyService
  ) 
  { 
    const img= _renderer.createElement("img");
    img.setAttribute("src","../../../../../assets/delete_icon.png");
    img.setAttribute("style","cursor:pointer;");
    img.width=25;
    img.height=25;
    _renderer.appendChild(element.nativeElement,img);
  }

  @Input() id:string;
  @Output() callback:EventEmitter<any>=new EventEmitter();

  @HostListener("click")
  onClick(){
  
    const td:HTMLTableCellElement=this.element.nativeElement;
    this.productService.delete(this.id);
  
    $(td.parentElement).fadeOut(2000);
    this.callback.emit();
    this.alertifyService.message("silindi",{
      dismissOthers:true,
      messageType:MessageType.Warning,
      position:Position.TopRight

    })
  }

}
