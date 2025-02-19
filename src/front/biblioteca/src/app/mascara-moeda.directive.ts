import { Directive, ElementRef, HostListener, forwardRef } from '@angular/core';
import { NG_VALUE_ACCESSOR, ControlValueAccessor } from '@angular/forms';

@Directive({
  selector: '[appMascaraMoeda]',
  providers: [
    {
      provide: NG_VALUE_ACCESSOR,
      useExisting: forwardRef(() => MascaraMoedaDirective),
      multi: true
    }
  ]
})

export class MascaraMoedaDirective implements ControlValueAccessor {
  private onChange!: (value: number) => void;
  private onTouched!: () => void;
  private el: HTMLInputElement;

  constructor(private elementRef: ElementRef) {
    this.el = this.elementRef.nativeElement;
  }

  @HostListener('input', ['$event.target.value'])
  onInput(value: string) {
    let numericValue = parseFloat(value.replace(/\D/g, '')) / 100; // Remove caracteres não numéricos e divide por 100
    if (isNaN(numericValue)) numericValue = 0;

    this.el.value = numericValue.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });

    if (this.onChange) this.onChange(numericValue);
  }

  writeValue(value: number): void {
    if (value !== undefined && value !== null) {
      this.el.value = value.toLocaleString('pt-BR', { style: 'currency', currency: 'BRL' });
    } else {
      this.el.value = '';
    }
  }

  registerOnChange(fn: any): void {
    this.onChange = fn;
  }

  registerOnTouched(fn: any): void {
    this.onTouched = fn;
  }

  setDisabledState?(isDisabled: boolean): void {
    this.el.disabled = isDisabled;
  }
}
