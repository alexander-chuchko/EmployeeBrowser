import { Directive, ElementRef, Input } from "@angular/core";

@Directive({
    selector:'[taskMarker]'
})
export class TaskDirective {
    @Input() taskMarker = '';

    constructor(private el: ElementRef) {
        this.el.nativeElement.style.backgroundColor =this.taskMarker;
    }
}