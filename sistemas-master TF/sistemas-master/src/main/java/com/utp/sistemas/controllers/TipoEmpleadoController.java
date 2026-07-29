package com.utp.sistemas.controllers;

import com.utp.sistemas.entities.TipoEmpleado;
import com.utp.sistemas.services.TipoEmpleadoService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.List;

@RestController
@RequestMapping("/api/tipo-empleados")
public class TipoEmpleadoController {

    @Autowired
    private TipoEmpleadoService tipoEmpleadoService;

    @PostMapping
    public TipoEmpleado createTipoEmpleado(@RequestBody TipoEmpleado tipoEmpleado) {
        return tipoEmpleadoService.createTipoEmpleado(tipoEmpleado);
    }

    @GetMapping
    public List<TipoEmpleado> getAllTipoEmpleados() {
        return tipoEmpleadoService.getAllTipoEmpleados();
    }

    @GetMapping("/{id}")
    public ResponseEntity<TipoEmpleado> getTipoEmpleadoById(@PathVariable Integer id) {
        return tipoEmpleadoService.getTipoEmpleadoById(id)
                .map(ResponseEntity::ok)
                .orElseGet(() -> ResponseEntity.notFound().build());
    }

    @PutMapping("/{id}")
    public ResponseEntity<TipoEmpleado> updateTipoEmpleado(@PathVariable Integer id, @RequestBody TipoEmpleado tipoEmpleadoDetails) {
        TipoEmpleado updatedTipoEmpleado = tipoEmpleadoService.updateTipoEmpleado(id, tipoEmpleadoDetails);
        return updatedTipoEmpleado != null ? ResponseEntity.ok(updatedTipoEmpleado) : ResponseEntity.notFound().build();
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<Void> deleteTipoEmpleado(@PathVariable Integer id) {
        tipoEmpleadoService.deleteTipoEmpleado(id);
        return ResponseEntity.noContent().build();
    }
}